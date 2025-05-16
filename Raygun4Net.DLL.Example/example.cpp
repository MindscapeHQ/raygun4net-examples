#include "pch.h"
#include "example.h"
#include "handler/exception_handler.h"
#include "sender/crash_report_sender.h"


bool minidump_callback(const wchar_t* dump_path, const wchar_t* minidump_id, void* context, EXCEPTION_POINTERS* exinfo, MDRawAssertionInfo* assertion, bool succeeded)

{
    google_breakpad::CrashReportSender sender(L"crash.checkpoint");

    std::wstring filename = L"_dump_path_";
    filename += L"\\";
    filename += minidump_id;
    filename += L".dmp";

    std::map<std::wstring, std::wstring> files;
    files.insert(std::make_pair(filename, filename));

    // At this point you may include custom data to be part of the crash report.
    std::map<std::wstring, std::wstring> userCustomData;
    userCustomData.insert(std::make_pair(L"desc", L"Hello World"));

    sender.SendCrashReport(L"https://api.raygun.com/entries/breakpad?apikey=paste_your_api_key_here", userCustomData, files, 0);

    return true;
}

google_breakpad::ExceptionHandler* pHandler = new google_breakpad::ExceptionHandler(L"_dump_path_", 0, minidump_callback, 0, google_breakpad::ExceptionHandler::HANDLER_ALL, MiniDumpNormal, L"", 0);

int division(int a, int b)
{
    return a / b;
}


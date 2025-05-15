#pragma once

#ifdef EXAMPLE_EXPORTS
#define EXAMPLE_API __declspec(dllexport)
#else
#define EXAMPLE_API __declspec(dllimport)
#endif

// Divides a by b and returns the result.
extern "C" EXAMPLE_API int division(int a, int b);

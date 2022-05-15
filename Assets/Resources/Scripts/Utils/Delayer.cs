using System;
using System.Collections;
using UnityEngine;

namespace Beathoven.Utils
{
    public static class Delayer
    {
        public static IEnumerator WaitFor(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback();
        }
        public static IEnumerator WaitFor(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}
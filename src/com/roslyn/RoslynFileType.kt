package com.roslyn

import com.intellij.lang.Language

class RoslynLanguage private constructor(): Language("Roslyn"){
    private object Holder {
        val INSTANCE = RoslynLanguage()
    }

    companion object {
        val instance: RoslynLanguage by lazy { Holder.INSTANCE }
    }

    over
}
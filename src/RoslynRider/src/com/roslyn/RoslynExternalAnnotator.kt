package com.roslyn

import com.intellij.lang.annotation.ExternalAnnotator
import com.intellij.psi.PsiFile
import com.jetbrains.rider.util.UsedImplicitly

@UsedImplicitly
public class RoslynExternalAnnotator private constructor() : ExternalAnnotator<Any, Any>() {
    override fun collectInformation(file: PsiFile): Any? {
        return super.collectInformation(file)
    }
}
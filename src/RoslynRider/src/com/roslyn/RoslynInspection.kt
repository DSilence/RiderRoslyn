package com.roslyn

import com.intellij.codeInspection.InspectionManager
import com.intellij.codeInspection.LocalInspectionTool
import com.intellij.codeInspection.ProblemDescriptor
import com.intellij.psi.PsiFile

class RoslynInspection : LocalInspectionTool(){
    override fun isEnabledByDefault(): Boolean {
        return super.isEnabledByDefault()
    }

    override fun isInitialized(): Boolean {
        return super.isInitialized()
    }
    override fun processFile(file: PsiFile, manager: InspectionManager): MutableList<ProblemDescriptor> {
        return super.processFile(file, manager)
    }
}
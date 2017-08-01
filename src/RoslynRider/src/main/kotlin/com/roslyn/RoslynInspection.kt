package com.roslyn

import com.intellij.codeInspection.InspectionManager
import com.intellij.codeInspection.LocalInspectionTool
import com.intellij.codeInspection.ProblemDescriptor
import com.intellij.psi.PsiFile

class RoslynInspection : LocalInspectionTool(){

    val INSPECTION_SHORT_NAME = "ESLintInspection"
    override fun isEnabledByDefault(): Boolean {
        return super.isEnabledByDefault()
    }

    override fun getID(): String {
        return "Settings.C#.Roslyn"
    }

    override fun getShortName(): String {
        return INSPECTION_SHORT_NAME
    }

    override fun checkFile(file: PsiFile, manager: InspectionManager, isOnTheFly: Boolean): Array<ProblemDescriptor>? {
        return super.checkFile(file, manager, isOnTheFly)
    }

    override fun processFile(file: PsiFile, manager: InspectionManager): MutableList<ProblemDescriptor> {
        return super.processFile(file, manager)
    }
}
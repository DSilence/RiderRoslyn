package com.roslyn

import com.intellij.openapi.components.ProjectComponent
import com.intellij.openapi.project.Project

class RoslynClientComponent private constructor(val project : Project): ProjectComponent {
    override fun getComponentName(): String {
        return "RoslynClient"
    }

    override fun initComponent() {
        // Start the client
    }

    override fun disposeComponent() {
    }

    override fun projectClosed() {
    }

    override fun projectOpened() {
    }
}
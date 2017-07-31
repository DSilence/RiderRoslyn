package com.roslyn

import com.intellij.openapi.components.ProjectComponent
import com.jetbrains.rider.util.UsedImplicitly

@UsedImplicitly
public class RoslynProjectComponent private constructor(): ProjectComponent {
    override fun disposeComponent() {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun projectClosed() {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun initComponent() {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun getComponentName(): String {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun projectOpened() {
        val t = 2
    }
}
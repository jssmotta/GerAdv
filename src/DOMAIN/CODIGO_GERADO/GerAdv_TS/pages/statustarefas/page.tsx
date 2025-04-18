﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { StatusTarefasGridAdapter } from "@/app/GerAdv_TS/StatusTarefas/Adapter/StatusTarefasGridAdapter";
import StatusTarefasGridContainer from "@/app/GerAdv_TS/StatusTarefas/Components/StatusTarefasGridContainer";

const StatusTarefasPage: React.FC = () => {
    const StatusTarefasGrid = new StatusTarefasGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Status Tarefas" />
            <StatusTarefasGridContainer grid={StatusTarefasGrid} />
        </PageLayout>
    );
};

export default StatusTarefasPage;
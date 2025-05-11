"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import StatusTarefasGrid from "@/app/GerAdv_TS/StatusTarefas/Crud/Grids/StatusTarefasGrid";

export class StatusTarefasGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <StatusTarefasGrid />;
    }
}
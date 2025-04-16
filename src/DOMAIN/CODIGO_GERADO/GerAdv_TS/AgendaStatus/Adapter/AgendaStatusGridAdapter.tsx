"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AgendaStatusGrid from "@/app/GerAdv_TS/AgendaStatus/Crud/Grids/AgendaStatusGrid";

export class AgendaStatusGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AgendaStatusGrid />;
    }
}
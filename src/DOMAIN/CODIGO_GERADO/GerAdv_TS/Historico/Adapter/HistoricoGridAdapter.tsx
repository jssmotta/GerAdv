"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import HistoricoGrid from "@/app/GerAdv_TS/Historico/Crud/Grids/HistoricoGrid";

export class HistoricoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <HistoricoGrid />;
    }
}
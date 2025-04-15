"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import LigacoesGrid from "@/app/GerAdv_TS/Ligacoes/Crud/Grids/LigacoesGrid";

export class LigacoesGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <LigacoesGrid />;
    }
}
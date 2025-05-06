"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import LivroCaixaClientesGrid from "@/app/GerAdv_TS/LivroCaixaClientes/Crud/Grids/LivroCaixaClientesGrid";

export class LivroCaixaClientesGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <LivroCaixaClientesGrid />;
    }
}
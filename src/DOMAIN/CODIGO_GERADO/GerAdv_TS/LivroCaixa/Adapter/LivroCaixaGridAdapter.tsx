"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import LivroCaixaGrid from "@/app/GerAdv_TS/LivroCaixa/Crud/Grids/LivroCaixaGrid";

export class LivroCaixaGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <LivroCaixaGrid />;
    }
}
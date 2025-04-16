"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ContaCorrenteGrid from "@/app/GerAdv_TS/ContaCorrente/Crud/Grids/ContaCorrenteGrid";

export class ContaCorrenteGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ContaCorrenteGrid />;
    }
}
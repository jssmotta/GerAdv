"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ContatoCRMOperadorGrid from "@/app/GerAdv_TS/ContatoCRMOperador/Crud/Grids/ContatoCRMOperadorGrid";

export class ContatoCRMOperadorGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ContatoCRMOperadorGrid />;
    }
}
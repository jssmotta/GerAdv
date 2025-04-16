"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import SetorGrid from "@/app/GerAdv_TS/Setor/Crud/Grids/SetorGrid";

export class SetorGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <SetorGrid />;
    }
}
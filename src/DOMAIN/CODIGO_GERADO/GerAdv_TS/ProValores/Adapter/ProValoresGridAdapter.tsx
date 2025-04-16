"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ProValoresGrid from "@/app/GerAdv_TS/ProValores/Crud/Grids/ProValoresGrid";

export class ProValoresGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ProValoresGrid />;
    }
}
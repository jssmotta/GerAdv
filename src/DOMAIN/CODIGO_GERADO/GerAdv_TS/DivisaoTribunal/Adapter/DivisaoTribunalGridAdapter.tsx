"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import DivisaoTribunalGrid from "@/app/GerAdv_TS/DivisaoTribunal/Crud/Grids/DivisaoTribunalGrid";

export class DivisaoTribunalGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <DivisaoTribunalGrid />;
    }
}
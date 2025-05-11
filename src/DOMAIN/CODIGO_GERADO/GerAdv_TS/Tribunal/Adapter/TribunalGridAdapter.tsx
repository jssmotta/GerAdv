"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TribunalGrid from "@/app/GerAdv_TS/Tribunal/Crud/Grids/TribunalGrid";

export class TribunalGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TribunalGrid />;
    }
}
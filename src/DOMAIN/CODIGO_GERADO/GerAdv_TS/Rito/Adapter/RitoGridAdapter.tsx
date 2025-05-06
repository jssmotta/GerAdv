"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import RitoGrid from "@/app/GerAdv_TS/Rito/Crud/Grids/RitoGrid";

export class RitoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <RitoGrid />;
    }
}
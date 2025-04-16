"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import HorasTrabGrid from "@/app/GerAdv_TS/HorasTrab/Crud/Grids/HorasTrabGrid";

export class HorasTrabGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <HorasTrabGrid />;
    }
}
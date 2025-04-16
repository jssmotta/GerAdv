"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import RamalGrid from "@/app/GerAdv_TS/Ramal/Crud/Grids/RamalGrid";

export class RamalGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <RamalGrid />;
    }
}
"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ContatoCRMViewGrid from "@/app/GerAdv_TS/ContatoCRMView/Crud/Grids/ContatoCRMViewGrid";

export class ContatoCRMViewGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ContatoCRMViewGrid />;
    }
}
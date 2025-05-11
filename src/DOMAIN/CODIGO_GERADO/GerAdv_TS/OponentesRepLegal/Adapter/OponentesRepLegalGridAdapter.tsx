"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import OponentesRepLegalGrid from "@/app/GerAdv_TS/OponentesRepLegal/Crud/Grids/OponentesRepLegalGrid";

export class OponentesRepLegalGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <OponentesRepLegalGrid />;
    }
}
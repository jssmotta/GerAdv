'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import InstanciaGrid from '@/app/GerAdv_TS/Instancia/Crud/Grids/InstanciaGrid';
export class InstanciaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <InstanciaGrid />;
  }
}
'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ObjetosGrid from '@/app/GerAdv_TS/Objetos/Crud/Grids/ObjetosGrid';
export class ObjetosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ObjetosGrid />;
  }
}
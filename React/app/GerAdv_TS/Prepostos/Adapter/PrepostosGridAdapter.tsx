'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import PrepostosGrid from '@/app/GerAdv_TS/Prepostos/Crud/Grids/PrepostosGrid';
export class PrepostosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <PrepostosGrid />;
  }
}
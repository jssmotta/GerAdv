'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AreasJusticaGridAdapter } from '@/app/GerAdv_TS/AreasJustica/Adapter/AreasJusticaGridAdapter';
import AreasJusticaGridContainer from '@/app/GerAdv_TS/AreasJustica/Components/AreasJusticaGridContainer';
const AreasJusticaPage: React.FC = () => {
  const AreasJusticaGrid = new AreasJusticaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Areas Justica' />
    <AreasJusticaGridContainer grid={AreasJusticaGrid} />
  </PageLayout>
);
};
export default AreasJusticaPage;
'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { JusticaGridAdapter } from '@/app/GerAdv_TS/Justica/Adapter/JusticaGridAdapter';
import JusticaGridContainer from '@/app/GerAdv_TS/Justica/Components/JusticaGridContainer';
const JusticaPage: React.FC = () => {
  const JusticaGrid = new JusticaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Justiça' />
    <JusticaGridContainer grid={JusticaGrid} />
  </PageLayout>
);
};
export default JusticaPage;
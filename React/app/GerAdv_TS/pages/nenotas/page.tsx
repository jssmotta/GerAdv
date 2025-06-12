'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { NENotasGridAdapter } from '@/app/GerAdv_TS/NENotas/Adapter/NENotasGridAdapter';
import NENotasGridContainer from '@/app/GerAdv_TS/NENotas/Components/NENotasGridContainer';
const NENotasPage: React.FC = () => {
  const NENotasGrid = new NENotasGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='N E Notas' />
    <NENotasGridContainer grid={NENotasGrid} />
  </PageLayout>
);
};
export default NENotasPage;
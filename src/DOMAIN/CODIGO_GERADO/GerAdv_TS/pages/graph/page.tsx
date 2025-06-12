'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { GraphGridAdapter } from '@/app/GerAdv_TS/Graph/Adapter/GraphGridAdapter';
import GraphGridContainer from '@/app/GerAdv_TS/Graph/Components/GraphGridContainer';
const GraphPage: React.FC = () => {
  const GraphGrid = new GraphGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Graph' />
    <GraphGridContainer grid={GraphGrid} />
  </PageLayout>
);
};
export default GraphPage;
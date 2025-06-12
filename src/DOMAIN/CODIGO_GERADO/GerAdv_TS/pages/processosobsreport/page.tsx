'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ProcessosObsReportGridAdapter } from '@/app/GerAdv_TS/ProcessosObsReport/Adapter/ProcessosObsReportGridAdapter';
import ProcessosObsReportGridContainer from '@/app/GerAdv_TS/ProcessosObsReport/Components/ProcessosObsReportGridContainer';
const ProcessosObsReportPage: React.FC = () => {
  const ProcessosObsReportGrid = new ProcessosObsReportGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Processos Obs Report' />
    <ProcessosObsReportGridContainer grid={ProcessosObsReportGrid} />
  </PageLayout>
);
};
export default ProcessosObsReportPage;
//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProcessosObsReportEmpty } from '../../../Models/ProcessosObsReport';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProcessosObsReport } from '../../Interfaces/interface.ProcessosObsReport';
import { ProcessosObsReportService } from '../../Services/ProcessosObsReport.service';
import { ProcessosObsReportApi } from '../../Apis/ApiProcessosObsReport';
import { ProcessosObsReportGridMobileComponent } from '../GridsMobile/ProcessosObsReport';
import { ProcessosObsReportGridDesktopComponent } from '../GridsDesktop/ProcessosObsReport';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProcessosObsReport } from '../../Filters/ProcessosObsReport';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProcessosObsReportWindow from './ProcessosObsReportWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProcessosObsReportList } from '../../Hooks/hookProcessosObsReport';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProcessosObsReportGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const processosobsreportService = useMemo(() => {
    return new ProcessosObsReportService(
    new ProcessosObsReportApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: processosobsreport, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProcessosObsReportList(processosobsreportService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProcessosObsReport, setSelectedProcessosObsReport] = useState<IProcessosObsReport>(ProcessosObsReportEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProcessosObsReport | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProcessosObsReport | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProcessosObsReport);
};
// Handlers para o grid
const handleRowClick = (processosobsreport: IProcessosObsReport) => {
  setSelectedProcessosObsReport(processosobsreport);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProcessosObsReport(ProcessosObsReportEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const processosobsreport = e.dataItem;
  setDeleteId(processosobsreport.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await processosobsreportService.deleteProcessosObsReport(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <ProcessosObsReportGridMobileComponent
    data={processosobsreport}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProcessosObsReportGridDesktopComponent
    data={processosobsreport}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProcessosObsReportWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProcessosObsReport={selectedProcessosObsReport}
    />

    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default ProcessosObsReportGrid;
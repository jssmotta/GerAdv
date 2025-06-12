//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProcessosParadosEmpty } from '../../../Models/ProcessosParados';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProcessosParados } from '../../Interfaces/interface.ProcessosParados';
import { ProcessosParadosService } from '../../Services/ProcessosParados.service';
import { ProcessosParadosApi } from '../../Apis/ApiProcessosParados';
import { ProcessosParadosGridMobileComponent } from '../GridsMobile/ProcessosParados';
import { ProcessosParadosGridDesktopComponent } from '../GridsDesktop/ProcessosParados';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProcessosParados } from '../../Filters/ProcessosParados';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProcessosParadosWindow from './ProcessosParadosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProcessosParadosList } from '../../Hooks/hookProcessosParados';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProcessosParadosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const processosparadosService = useMemo(() => {
    return new ProcessosParadosService(
    new ProcessosParadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: processosparados, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProcessosParadosList(processosparadosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProcessosParados, setSelectedProcessosParados] = useState<IProcessosParados>(ProcessosParadosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProcessosParados | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProcessosParados | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProcessosParados);
};
// Handlers para o grid
const handleRowClick = (processosparados: IProcessosParados) => {
  setSelectedProcessosParados(processosparados);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProcessosParados(ProcessosParadosEmpty());
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
  const processosparados = e.dataItem;
  setDeleteId(processosparados.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await processosparadosService.deleteProcessosParados(deleteId);
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
    <ProcessosParadosGridMobileComponent
    data={processosparados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProcessosParadosGridDesktopComponent
    data={processosparados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProcessosParadosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProcessosParados={selectedProcessosParados}
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
export default ProcessosParadosGrid;
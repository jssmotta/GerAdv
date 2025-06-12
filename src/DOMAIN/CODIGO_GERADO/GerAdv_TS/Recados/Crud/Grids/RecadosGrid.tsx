//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { RecadosEmpty } from '../../../Models/Recados';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IRecados } from '../../Interfaces/interface.Recados';
import { RecadosService } from '../../Services/Recados.service';
import { RecadosApi } from '../../Apis/ApiRecados';
import { RecadosGridMobileComponent } from '../GridsMobile/Recados';
import { RecadosGridDesktopComponent } from '../GridsDesktop/Recados';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterRecados } from '../../Filters/Recados';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import RecadosWindow from './RecadosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useRecadosList } from '../../Hooks/hookRecados';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const RecadosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const recadosService = useMemo(() => {
    return new RecadosService(
    new RecadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: recados, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useRecadosList(recadosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedRecados, setSelectedRecados] = useState<IRecados>(RecadosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterRecados | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterRecados | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterRecados);
};
// Handlers para o grid
const handleRowClick = (recados: IRecados) => {
  setSelectedRecados(recados);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedRecados(RecadosEmpty());
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
  const recados = e.dataItem;
  setDeleteId(recados.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await recadosService.deleteRecados(deleteId);
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
    <RecadosGridMobileComponent
    data={recados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <RecadosGridDesktopComponent
    data={recados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <RecadosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedRecados={selectedRecados}
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
export default RecadosGrid;
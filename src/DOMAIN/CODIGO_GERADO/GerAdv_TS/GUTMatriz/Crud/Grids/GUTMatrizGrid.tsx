//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GUTMatrizEmpty } from '../../../Models/GUTMatriz';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGUTMatriz } from '../../Interfaces/interface.GUTMatriz';
import { GUTMatrizService } from '../../Services/GUTMatriz.service';
import { GUTMatrizApi } from '../../Apis/ApiGUTMatriz';
import { GUTMatrizGridMobileComponent } from '../GridsMobile/GUTMatriz';
import { GUTMatrizGridDesktopComponent } from '../GridsDesktop/GUTMatriz';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGUTMatriz } from '../../Filters/GUTMatriz';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GUTMatrizWindow from './GUTMatrizWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGUTMatrizList } from '../../Hooks/hookGUTMatriz';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const GUTMatrizGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const gutmatrizService = useMemo(() => {
    return new GUTMatrizService(
    new GUTMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: gutmatriz, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGUTMatrizList(gutmatrizService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGUTMatriz, setSelectedGUTMatriz] = useState<IGUTMatriz>(GUTMatrizEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGUTMatriz | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGUTMatriz | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGUTMatriz);
};
// Handlers para o grid
const handleRowClick = (gutmatriz: IGUTMatriz) => {
  setSelectedGUTMatriz(gutmatriz);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGUTMatriz(GUTMatrizEmpty());
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
  const gutmatriz = e.dataItem;
  setDeleteId(gutmatriz.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await gutmatrizService.deleteGUTMatriz(deleteId);
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
    <GUTMatrizGridMobileComponent
    data={gutmatriz}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GUTMatrizGridDesktopComponent
    data={gutmatriz}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GUTMatrizWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGUTMatriz={selectedGUTMatriz}
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
export default GUTMatrizGrid;
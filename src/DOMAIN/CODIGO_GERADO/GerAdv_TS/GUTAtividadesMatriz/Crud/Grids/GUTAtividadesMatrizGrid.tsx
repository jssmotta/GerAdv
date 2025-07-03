//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GUTAtividadesMatrizEmpty } from '../../../Models/GUTAtividadesMatriz';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGUTAtividadesMatriz } from '../../Interfaces/interface.GUTAtividadesMatriz';
import { GUTAtividadesMatrizService } from '../../Services/GUTAtividadesMatriz.service';
import { GUTAtividadesMatrizApi } from '../../Apis/ApiGUTAtividadesMatriz';
import { GUTAtividadesMatrizGridMobileComponent } from '../GridsMobile/GUTAtividadesMatriz';
import { GUTAtividadesMatrizGridDesktopComponent } from '../GridsDesktop/GUTAtividadesMatriz';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGUTAtividadesMatriz } from '../../Filters/GUTAtividadesMatriz';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GUTAtividadesMatrizWindow from './GUTAtividadesMatrizWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGUTAtividadesMatrizList } from '../../Hooks/hookGUTAtividadesMatriz';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const GUTAtividadesMatrizGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const gutatividadesmatrizService = useMemo(() => {
    return new GUTAtividadesMatrizService(
    new GUTAtividadesMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: gutatividadesmatriz, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGUTAtividadesMatrizList(gutatividadesmatrizService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGUTAtividadesMatriz, setSelectedGUTAtividadesMatriz] = useState<IGUTAtividadesMatriz>(GUTAtividadesMatrizEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGUTAtividadesMatriz | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGUTAtividadesMatriz | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGUTAtividadesMatriz);
};
// Handlers para o grid
const handleRowClick = (gutatividadesmatriz: IGUTAtividadesMatriz) => {
  setSelectedGUTAtividadesMatriz(gutatividadesmatriz);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGUTAtividadesMatriz(GUTAtividadesMatrizEmpty());
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
  const gutatividadesmatriz = e.dataItem;
  setDeleteId(gutatividadesmatriz.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await gutatividadesmatrizService.deleteGUTAtividadesMatriz(deleteId);
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
    <GUTAtividadesMatrizGridMobileComponent
    data={gutatividadesmatriz}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GUTAtividadesMatrizGridDesktopComponent
    data={gutatividadesmatriz}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GUTAtividadesMatrizWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGUTAtividadesMatriz={selectedGUTAtividadesMatriz}
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
export default GUTAtividadesMatrizGrid;
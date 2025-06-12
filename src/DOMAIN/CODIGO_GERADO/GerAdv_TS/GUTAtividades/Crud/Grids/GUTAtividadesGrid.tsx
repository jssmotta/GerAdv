//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GUTAtividadesEmpty } from '../../../Models/GUTAtividades';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGUTAtividades } from '../../Interfaces/interface.GUTAtividades';
import { GUTAtividadesService } from '../../Services/GUTAtividades.service';
import { GUTAtividadesApi } from '../../Apis/ApiGUTAtividades';
import { GUTAtividadesGridMobileComponent } from '../GridsMobile/GUTAtividades';
import { GUTAtividadesGridDesktopComponent } from '../GridsDesktop/GUTAtividades';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGUTAtividades } from '../../Filters/GUTAtividades';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GUTAtividadesWindow from './GUTAtividadesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGUTAtividadesList } from '../../Hooks/hookGUTAtividades';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const GUTAtividadesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const gutatividadesService = useMemo(() => {
    return new GUTAtividadesService(
    new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: gutatividades, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGUTAtividadesList(gutatividadesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGUTAtividades, setSelectedGUTAtividades] = useState<IGUTAtividades>(GUTAtividadesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGUTAtividades | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGUTAtividades | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGUTAtividades);
};
// Handlers para o grid
const handleRowClick = (gutatividades: IGUTAtividades) => {
  setSelectedGUTAtividades(gutatividades);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGUTAtividades(GUTAtividadesEmpty());
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
  const gutatividades = e.dataItem;
  setDeleteId(gutatividades.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await gutatividadesService.deleteGUTAtividades(deleteId);
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
    <GUTAtividadesGridMobileComponent
    data={gutatividades}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GUTAtividadesGridDesktopComponent
    data={gutatividades}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GUTAtividadesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGUTAtividades={selectedGUTAtividades}
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
export default GUTAtividadesGrid;
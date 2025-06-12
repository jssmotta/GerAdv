//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AreasJusticaEmpty } from '../../../Models/AreasJustica';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAreasJustica } from '../../Interfaces/interface.AreasJustica';
import { AreasJusticaService } from '../../Services/AreasJustica.service';
import { AreasJusticaApi } from '../../Apis/ApiAreasJustica';
import { AreasJusticaGridMobileComponent } from '../GridsMobile/AreasJustica';
import { AreasJusticaGridDesktopComponent } from '../GridsDesktop/AreasJustica';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAreasJustica } from '../../Filters/AreasJustica';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AreasJusticaWindow from './AreasJusticaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAreasJusticaList } from '../../Hooks/hookAreasJustica';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const AreasJusticaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const areasjusticaService = useMemo(() => {
    return new AreasJusticaService(
    new AreasJusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: areasjustica, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAreasJusticaList(areasjusticaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAreasJustica, setSelectedAreasJustica] = useState<IAreasJustica>(AreasJusticaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAreasJustica | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAreasJustica | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAreasJustica);
};
// Handlers para o grid
const handleRowClick = (areasjustica: IAreasJustica) => {
  setSelectedAreasJustica(areasjustica);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAreasJustica(AreasJusticaEmpty());
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
  const areasjustica = e.dataItem;
  setDeleteId(areasjustica.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await areasjusticaService.deleteAreasJustica(deleteId);
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
    <AreasJusticaGridMobileComponent
    data={areasjustica}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AreasJusticaGridDesktopComponent
    data={areasjustica}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AreasJusticaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAreasJustica={selectedAreasJustica}
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
export default AreasJusticaGrid;
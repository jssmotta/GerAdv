//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NEPalavrasChavesEmpty } from '../../../Models/NEPalavrasChaves';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { INEPalavrasChaves } from '../../Interfaces/interface.NEPalavrasChaves';
import { NEPalavrasChavesService } from '../../Services/NEPalavrasChaves.service';
import { NEPalavrasChavesApi } from '../../Apis/ApiNEPalavrasChaves';
import { NEPalavrasChavesGridMobileComponent } from '../GridsMobile/NEPalavrasChaves';
import { NEPalavrasChavesGridDesktopComponent } from '../GridsDesktop/NEPalavrasChaves';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterNEPalavrasChaves } from '../../Filters/NEPalavrasChaves';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import NEPalavrasChavesWindow from './NEPalavrasChavesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useNEPalavrasChavesList } from '../../Hooks/hookNEPalavrasChaves';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const NEPalavrasChavesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const nepalavraschavesService = useMemo(() => {
    return new NEPalavrasChavesService(
    new NEPalavrasChavesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: nepalavraschaves, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useNEPalavrasChavesList(nepalavraschavesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedNEPalavrasChaves, setSelectedNEPalavrasChaves] = useState<INEPalavrasChaves>(NEPalavrasChavesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterNEPalavrasChaves | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterNEPalavrasChaves | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterNEPalavrasChaves);
};
// Handlers para o grid
const handleRowClick = (nepalavraschaves: INEPalavrasChaves) => {
  setSelectedNEPalavrasChaves(nepalavraschaves);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedNEPalavrasChaves(NEPalavrasChavesEmpty());
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
  const nepalavraschaves = e.dataItem;
  setDeleteId(nepalavraschaves.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await nepalavraschavesService.deleteNEPalavrasChaves(deleteId);
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
    <NEPalavrasChavesGridMobileComponent
    data={nepalavraschaves}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <NEPalavrasChavesGridDesktopComponent
    data={nepalavraschaves}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <NEPalavrasChavesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedNEPalavrasChaves={selectedNEPalavrasChaves}
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
export default NEPalavrasChavesGrid;
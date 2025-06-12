//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { FuncaoEmpty } from '../../../Models/Funcao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IFuncao } from '../../Interfaces/interface.Funcao';
import { FuncaoService } from '../../Services/Funcao.service';
import { FuncaoApi } from '../../Apis/ApiFuncao';
import { FuncaoGridMobileComponent } from '../GridsMobile/Funcao';
import { FuncaoGridDesktopComponent } from '../GridsDesktop/Funcao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterFuncao } from '../../Filters/Funcao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import FuncaoWindow from './FuncaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useFuncaoList } from '../../Hooks/hookFuncao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const FuncaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const funcaoService = useMemo(() => {
    return new FuncaoService(
    new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: funcao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useFuncaoList(funcaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedFuncao, setSelectedFuncao] = useState<IFuncao>(FuncaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterFuncao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterFuncao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterFuncao);
};
// Handlers para o grid
const handleRowClick = (funcao: IFuncao) => {
  setSelectedFuncao(funcao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedFuncao(FuncaoEmpty());
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
  const funcao = e.dataItem;
  setDeleteId(funcao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await funcaoService.deleteFuncao(deleteId);
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
    <FuncaoGridMobileComponent
    data={funcao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <FuncaoGridDesktopComponent
    data={funcao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <FuncaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedFuncao={selectedFuncao}
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
export default FuncaoGrid;
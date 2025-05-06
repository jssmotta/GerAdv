//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoValorProcessoEmpty } from "../../../Models/TipoValorProcesso";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ITipoValorProcesso } from "../../Interfaces/interface.TipoValorProcesso";
import { TipoValorProcessoService } from "../../Services/TipoValorProcesso.service";
import { TipoValorProcessoApi } from "../../Apis/ApiTipoValorProcesso";
import { TipoValorProcessoGridMobileComponent } from "../GridsMobile/TipoValorProcesso";
import { TipoValorProcessoGridDesktopComponent } from "../GridsDesktop/TipoValorProcesso";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoValorProcesso } from "../../Filters/TipoValorProcesso";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import TipoValorProcessoWindow from "./TipoValorProcessoWindow";

const TipoValorProcessoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipovalorprocesso, setTipoValorProcesso] = useState<ITipoValorProcesso[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoValorProcesso, setSelectedTipoValorProcesso] = useState<ITipoValorProcesso>(TipoValorProcessoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoValorProcessoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoValorProcesso | undefined | null>(null);

    const tipovalorprocessoService = useMemo(() => {
      return new TipoValorProcessoService(
          new TipoValorProcessoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoValorProcesso = async (filtro?: FilterTipoValorProcesso | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipovalorprocessoService.getList(filtro ?? {} as FilterTipoValorProcesso);
        setTipoValorProcesso(data);
      }
      else {
        const data = await tipovalorprocessoService.getAll(filtro ?? {} as FilterTipoValorProcesso);
        setTipoValorProcesso(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoValorProcesso(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipovalorprocesso: ITipoValorProcesso) => {
      if (isMobile) {
        router.push(`/pages/tipovalorprocesso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipovalorprocesso.id}`);
      } else {
        setSelectedTipoValorProcesso(tipovalorprocesso);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipovalorprocesso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoValorProcesso(TipoValorProcessoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoValorProcesso(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipovalorprocesso = e.dataItem;		
        setDeleteId(tipovalorprocesso.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoValorProcesso(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <TipoValorProcessoGridMobileComponent data={tipovalorprocesso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <TipoValorProcessoGridDesktopComponent data={tipovalorprocesso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <TipoValorProcessoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoValorProcesso={selectedTipoValorProcesso}>       
        </TipoValorProcessoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoValorProcessoGrid;
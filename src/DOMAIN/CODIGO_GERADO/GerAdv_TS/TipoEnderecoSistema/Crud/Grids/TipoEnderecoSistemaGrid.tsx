//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoEnderecoSistemaEmpty } from "../../../Models/TipoEnderecoSistema";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ITipoEnderecoSistema } from "../../Interfaces/interface.TipoEnderecoSistema";
import { TipoEnderecoSistemaService } from "../../Services/TipoEnderecoSistema.service";
import { TipoEnderecoSistemaApi } from "../../Apis/ApiTipoEnderecoSistema";
import { TipoEnderecoSistemaGridMobileComponent } from "../GridsMobile/TipoEnderecoSistema";
import { TipoEnderecoSistemaGridDesktopComponent } from "../GridsDesktop/TipoEnderecoSistema";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoEnderecoSistema } from "../../Filters/TipoEnderecoSistema";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import TipoEnderecoSistemaWindow from "./TipoEnderecoSistemaWindow";

const TipoEnderecoSistemaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipoenderecosistema, setTipoEnderecoSistema] = useState<ITipoEnderecoSistema[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoEnderecoSistema, setSelectedTipoEnderecoSistema] = useState<ITipoEnderecoSistema>(TipoEnderecoSistemaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoEnderecoSistema | undefined | null>(null);

    const tipoenderecosistemaService = useMemo(() => {
      return new TipoEnderecoSistemaService(
          new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoEnderecoSistema = async (filtro?: FilterTipoEnderecoSistema | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipoenderecosistemaService.getList(filtro ?? {} as FilterTipoEnderecoSistema);
        setTipoEnderecoSistema(data);
      }
      else {
        const data = await tipoenderecosistemaService.getAll(filtro ?? {} as FilterTipoEnderecoSistema);
        setTipoEnderecoSistema(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoEnderecoSistema(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipoenderecosistema: ITipoEnderecoSistema) => {
      if (isMobile) {
        router.push(`/pages/tipoenderecosistema/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipoenderecosistema.id}`);
      } else {
        setSelectedTipoEnderecoSistema(tipoenderecosistema);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipoenderecosistema/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoEnderecoSistema(TipoEnderecoSistemaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoEnderecoSistema(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipoenderecosistema = e.dataItem;		
        setDeleteId(tipoenderecosistema.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoEnderecoSistema(currFilter);
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
           <TipoEnderecoSistemaGridMobileComponent data={tipoenderecosistema} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <TipoEnderecoSistemaGridDesktopComponent data={tipoenderecosistema} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <TipoEnderecoSistemaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoEnderecoSistema={selectedTipoEnderecoSistema}>       
        </TipoEnderecoSistemaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoEnderecoSistemaGrid;
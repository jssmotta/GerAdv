//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { EnderecoSistemaEmpty } from "../../../Models/EnderecoSistema";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IEnderecoSistema } from "../../Interfaces/interface.EnderecoSistema";
import { EnderecoSistemaService } from "../../Services/EnderecoSistema.service";
import { EnderecoSistemaApi } from "../../Apis/ApiEnderecoSistema";
import { EnderecoSistemaGridMobileComponent } from "../GridsMobile/EnderecoSistema";
import { EnderecoSistemaGridDesktopComponent } from "../GridsDesktop/EnderecoSistema";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterEnderecoSistema } from "../../Filters/EnderecoSistema";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import EnderecoSistemaWindow from "./EnderecoSistemaWindow";

const EnderecoSistemaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [enderecosistema, setEnderecoSistema] = useState<IEnderecoSistema[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedEnderecoSistema, setSelectedEnderecoSistema] = useState<IEnderecoSistema>(EnderecoSistemaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new EnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterEnderecoSistema | undefined | null>(null);

    const enderecosistemaService = useMemo(() => {
      return new EnderecoSistemaService(
          new EnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchEnderecoSistema = async (filtro?: FilterEnderecoSistema | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await enderecosistemaService.getAll(filtro ?? {} as FilterEnderecoSistema);
        setEnderecoSistema(data);
      }
      else {
        const data = await enderecosistemaService.getAll(filtro ?? {} as FilterEnderecoSistema);
        setEnderecoSistema(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchEnderecoSistema(currFilter);
    }, [showInc]);
  
    const handleRowClick = (enderecosistema: IEnderecoSistema) => {
      if (isMobile) {
        router.push(`/pages/enderecosistema/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${enderecosistema.id}`);
      } else {
        setSelectedEnderecoSistema(enderecosistema);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/enderecosistema/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedEnderecoSistema(EnderecoSistemaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchEnderecoSistema(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const enderecosistema = e.dataItem;		
        setDeleteId(enderecosistema.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchEnderecoSistema(currFilter);
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
            
        {isMobile ?
           <EnderecoSistemaGridMobileComponent data={enderecosistema} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <EnderecoSistemaGridDesktopComponent data={enderecosistema} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <EnderecoSistemaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedEnderecoSistema={selectedEnderecoSistema}>       
        </EnderecoSistemaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default EnderecoSistemaGrid;
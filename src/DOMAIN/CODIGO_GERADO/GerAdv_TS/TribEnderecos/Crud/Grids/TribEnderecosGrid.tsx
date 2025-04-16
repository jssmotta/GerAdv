//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TribEnderecosEmpty } from "../../../Models/TribEnderecos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TribEnderecosInc from "../Inc/TribEnderecos";
import { ITribEnderecos } from "../../Interfaces/interface.TribEnderecos";
import { TribEnderecosService } from "../../Services/TribEnderecos.service";
import { TribEnderecosApi } from "../../Apis/ApiTribEnderecos";
import { TribEnderecosGridMobileComponent } from "../GridsMobile/TribEnderecos";
import { TribEnderecosGridDesktopComponent } from "../GridsDesktop/TribEnderecos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTribEnderecos } from "../../Filters/TribEnderecos";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TribEnderecosWindow from "./TribEnderecosWindow";

const TribEnderecosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tribenderecos, setTribEnderecos] = useState<ITribEnderecos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTribEnderecos, setSelectedTribEnderecos] = useState<ITribEnderecos>(TribEnderecosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TribEnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTribEnderecos | undefined | null>(null);

    const tribenderecosService = useMemo(() => {
      return new TribEnderecosService(
          new TribEnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTribEnderecos = async (filtro?: FilterTribEnderecos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tribenderecosService.getAll(filtro ?? {} as FilterTribEnderecos);
        setTribEnderecos(data);
      }
      else {
        const data = await tribenderecosService.getAll(filtro ?? {} as FilterTribEnderecos);
        setTribEnderecos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTribEnderecos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tribenderecos: ITribEnderecos) => {
      if (isMobile) {
        router.push(`/pages/tribenderecos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tribenderecos.id}`);
      } else {
        setSelectedTribEnderecos(tribenderecos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tribenderecos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTribEnderecos(TribEnderecosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTribEnderecos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tribenderecos = e.dataItem;		
        setDeleteId(tribenderecos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTribEnderecos(currFilter);
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
           <TribEnderecosGridMobileComponent data={tribenderecos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TribEnderecosGridDesktopComponent data={tribenderecos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TribEnderecosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTribEnderecos={selectedTribEnderecos}>       
        </TribEnderecosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TribEnderecosGrid;
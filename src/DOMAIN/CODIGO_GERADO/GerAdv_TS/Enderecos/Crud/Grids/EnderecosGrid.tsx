//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { EnderecosEmpty } from "../../../Models/Enderecos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import EnderecosInc from "../Inc/Enderecos";
import { IEnderecos } from "../../Interfaces/interface.Enderecos";
import { EnderecosService } from "../../Services/Enderecos.service";
import { EnderecosApi } from "../../Apis/ApiEnderecos";
import { EnderecosGridMobileComponent } from "../GridsMobile/Enderecos";
import { EnderecosGridDesktopComponent } from "../GridsDesktop/Enderecos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterEnderecos } from "../../Filters/Enderecos";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import EnderecosWindow from "./EnderecosWindow";

const EnderecosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [enderecos, setEnderecos] = useState<IEnderecos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedEnderecos, setSelectedEnderecos] = useState<IEnderecos>(EnderecosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new EnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterEnderecos | undefined | null>(null);

    const enderecosService = useMemo(() => {
      return new EnderecosService(
          new EnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchEnderecos = async (filtro?: FilterEnderecos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await enderecosService.getList(filtro ?? {} as FilterEnderecos);
        setEnderecos(data);
      }
      else {
        const data = await enderecosService.getAll(filtro ?? {} as FilterEnderecos);
        setEnderecos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchEnderecos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (enderecos: IEnderecos) => {
      if (isMobile) {
        router.push(`/pages/enderecos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${enderecos.id}`);
      } else {
        setSelectedEnderecos(enderecos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/enderecos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedEnderecos(EnderecosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchEnderecos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const enderecos = e.dataItem;		
        setDeleteId(enderecos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchEnderecos(currFilter);
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
           <EnderecosGridMobileComponent data={enderecos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <EnderecosGridDesktopComponent data={enderecos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <EnderecosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedEnderecos={selectedEnderecos}>       
        </EnderecosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default EnderecosGrid;
//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProTipoBaixaEmpty } from "../../../Models/ProTipoBaixa";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProTipoBaixaInc from "../Inc/ProTipoBaixa";
import { IProTipoBaixa } from "../../Interfaces/interface.ProTipoBaixa";
import { ProTipoBaixaService } from "../../Services/ProTipoBaixa.service";
import { ProTipoBaixaApi } from "../../Apis/ApiProTipoBaixa";
import { ProTipoBaixaGridMobileComponent } from "../GridsMobile/ProTipoBaixa";
import { ProTipoBaixaGridDesktopComponent } from "../GridsDesktop/ProTipoBaixa";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProTipoBaixa } from "../../Filters/ProTipoBaixa";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProTipoBaixaWindow from "./ProTipoBaixaWindow";

const ProTipoBaixaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [protipobaixa, setProTipoBaixa] = useState<IProTipoBaixa[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProTipoBaixa, setSelectedProTipoBaixa] = useState<IProTipoBaixa>(ProTipoBaixaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProTipoBaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProTipoBaixa | undefined | null>(null);

    const protipobaixaService = useMemo(() => {
      return new ProTipoBaixaService(
          new ProTipoBaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProTipoBaixa = async (filtro?: FilterProTipoBaixa | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await protipobaixaService.getList(filtro ?? {} as FilterProTipoBaixa);
        setProTipoBaixa(data);
      }
      else {
        const data = await protipobaixaService.getAll(filtro ?? {} as FilterProTipoBaixa);
        setProTipoBaixa(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProTipoBaixa(currFilter);
    }, [showInc]);
  
    const handleRowClick = (protipobaixa: IProTipoBaixa) => {
      if (isMobile) {
        router.push(`/pages/protipobaixa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${protipobaixa.id}`);
      } else {
        setSelectedProTipoBaixa(protipobaixa);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/protipobaixa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProTipoBaixa(ProTipoBaixaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProTipoBaixa(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const protipobaixa = e.dataItem;		
        setDeleteId(protipobaixa.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProTipoBaixa(currFilter);
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
           <ProTipoBaixaGridMobileComponent data={protipobaixa} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProTipoBaixaGridDesktopComponent data={protipobaixa} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProTipoBaixaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProTipoBaixa={selectedProTipoBaixa}>       
        </ProTipoBaixaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProTipoBaixaGrid;
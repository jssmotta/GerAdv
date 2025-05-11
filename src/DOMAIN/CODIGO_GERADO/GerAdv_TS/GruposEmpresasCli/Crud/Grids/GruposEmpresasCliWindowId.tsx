// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IGruposEmpresasCli } from "../../Interfaces/interface.GruposEmpresasCli";
import { GruposEmpresasCliService } from "../../Services/GruposEmpresasCli.service";
import { GruposEmpresasCliApi } from "../../Apis/ApiGruposEmpresasCli";
import GruposEmpresasCliWindow from "./GruposEmpresasCliWindow";

interface GruposEmpresasCliWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const GruposEmpresasCliWindowId: React.FC<GruposEmpresasCliWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const gruposempresascliService = useMemo(() => {
        return new GruposEmpresasCliService(
            new GruposEmpresasCliApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IGruposEmpresasCli | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await gruposempresascliService.fetchGruposEmpresasCliById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <GruposEmpresasCliWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedGruposEmpresasCli={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default GruposEmpresasCliWindowId;
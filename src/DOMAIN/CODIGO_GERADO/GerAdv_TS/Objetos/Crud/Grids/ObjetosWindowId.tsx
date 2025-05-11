// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IObjetos } from "../../Interfaces/interface.Objetos";
import { ObjetosService } from "../../Services/Objetos.service";
import { ObjetosApi } from "../../Apis/ApiObjetos";
import ObjetosWindow from "./ObjetosWindow";

interface ObjetosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ObjetosWindowId: React.FC<ObjetosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const objetosService = useMemo(() => {
        return new ObjetosService(
            new ObjetosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IObjetos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await objetosService.fetchObjetosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ObjetosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedObjetos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ObjetosWindowId;
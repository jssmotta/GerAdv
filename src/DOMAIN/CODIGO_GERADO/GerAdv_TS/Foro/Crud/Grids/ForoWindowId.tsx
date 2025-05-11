// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IForo } from "../../Interfaces/interface.Foro";
import { ForoService } from "../../Services/Foro.service";
import { ForoApi } from "../../Apis/ApiForo";
import ForoWindow from "./ForoWindow";

interface ForoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ForoWindowId: React.FC<ForoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const foroService = useMemo(() => {
        return new ForoService(
            new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IForo | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await foroService.fetchForoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ForoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedForo={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ForoWindowId;
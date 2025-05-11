// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IOponentesRepLegal } from "../../Interfaces/interface.OponentesRepLegal";
import { OponentesRepLegalService } from "../../Services/OponentesRepLegal.service";
import { OponentesRepLegalApi } from "../../Apis/ApiOponentesRepLegal";
import OponentesRepLegalWindow from "./OponentesRepLegalWindow";

interface OponentesRepLegalWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const OponentesRepLegalWindowId: React.FC<OponentesRepLegalWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const oponentesreplegalService = useMemo(() => {
        return new OponentesRepLegalService(
            new OponentesRepLegalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IOponentesRepLegal | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await oponentesreplegalService.fetchOponentesRepLegalById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <OponentesRepLegalWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedOponentesRepLegal={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default OponentesRepLegalWindowId;
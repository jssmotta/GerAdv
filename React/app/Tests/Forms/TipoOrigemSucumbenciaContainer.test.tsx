import React from 'react';
import { render } from '@testing-library/react';
import TipoOrigemSucumbenciaIncContainer from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Components/TipoOrigemSucumbenciaIncContainer';
// TipoOrigemSucumbenciaIncContainer.test.tsx
// Mock do TipoOrigemSucumbenciaInc
jest.mock('@/app/GerAdv_TS/TipoOrigemSucumbencia/Crud/Inc/TipoOrigemSucumbencia', () => (props: any) => (
<div data-testid='tipoorigemsucumbencia-inc-mock' {...props} />
));
describe('TipoOrigemSucumbenciaIncContainer', () => {
  it('deve renderizar TipoOrigemSucumbenciaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <TipoOrigemSucumbenciaIncContainer id={id} navigator={mockNavigator} />
  );
  const tipoorigemsucumbenciaInc = getByTestId('tipoorigemsucumbencia-inc-mock');
  expect(tipoorigemsucumbenciaInc).toBeInTheDocument();
  expect(tipoorigemsucumbenciaInc.getAttribute('id')).toBe(id.toString());

});
});
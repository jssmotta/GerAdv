import React from 'react';
import { render } from '@testing-library/react';
import OperadorGrupoIncContainer from '@/app/GerAdv_TS/OperadorGrupo/Components/OperadorGrupoIncContainer';
// OperadorGrupoIncContainer.test.tsx
// Mock do OperadorGrupoInc
jest.mock('@/app/GerAdv_TS/OperadorGrupo/Crud/Inc/OperadorGrupo', () => (props: any) => (
<div data-testid='operadorgrupo-inc-mock' {...props} />
));
describe('OperadorGrupoIncContainer', () => {
  it('deve renderizar OperadorGrupoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <OperadorGrupoIncContainer id={id} navigator={mockNavigator} />
  );
  const operadorgrupoInc = getByTestId('operadorgrupo-inc-mock');
  expect(operadorgrupoInc).toBeInTheDocument();
  expect(operadorgrupoInc.getAttribute('id')).toBe(id.toString());

});
});
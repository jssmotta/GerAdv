import React from 'react';
import { render } from '@testing-library/react';
import JusticaIncContainer from '@/app/GerAdv_TS/Justica/Components/JusticaIncContainer';
// JusticaIncContainer.test.tsx
// Mock do JusticaInc
jest.mock('@/app/GerAdv_TS/Justica/Crud/Inc/Justica', () => (props: any) => (
<div data-testid='justica-inc-mock' {...props} />
));
describe('JusticaIncContainer', () => {
  it('deve renderizar JusticaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <JusticaIncContainer id={id} navigator={mockNavigator} />
  );
  const justicaInc = getByTestId('justica-inc-mock');
  expect(justicaInc).toBeInTheDocument();
  expect(justicaInc.getAttribute('id')).toBe(id.toString());

});
});